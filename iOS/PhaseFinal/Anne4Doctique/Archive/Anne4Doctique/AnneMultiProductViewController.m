//
//  AnneMultiProductViewController.m
//  MultiProductViewer
//
//  Created by JN on 2014-3-19.
//  Copyright (c) 2014 thoughtbot, inc. All rights reserved.
//

#import "AnneMultiProductViewController.h"
#import "AnneProductCluster.h"
#import "AnneProduct.h"
#import "AnneProductViewCell.h"
#import "AnneProductClusterHeaderCell.h"
#import <StoreKit/StoreKit.h>

@interface AnneMultiProductViewController () <SKStoreProductViewControllerDelegate>

@property (copy, nonatomic) NSArray *productClusters;
@property (copy, nonatomic) NSString *title;
@property (weak, nonatomic) id <AnneMultiProductViewControllerDelegate> delegate;
@property (strong, nonatomic) UIViewController *parent;

@end

@implementation AnneMultiProductViewController

+ (void)runWithTitle:(NSString *)title
     productClusters:(NSArray *)clusters
            delegate:(id <AnneMultiProductViewControllerDelegate>)delegate {
    AnneMultiProductViewController *c = [[self alloc] init];
    c.title = title;
    c.productClusters = clusters;
    c.delegate = delegate;
    [c run];
}

- (void)run {
    UINavigationController *navCon = [[UINavigationController alloc] init];
    navCon.viewControllers = @[self];
    [self.parent presentViewController:navCon animated:YES completion:nil];
}

- (instancetype)init {
    if (!(self = [self initWithCollectionViewLayout:
                  [[UICollectionViewFlowLayout alloc] init]])) return nil;
    
    self.parent = [[UIApplication sharedApplication].windows.firstObject rootViewController];
    
    return self;
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    UIBarButtonItem *cancelButton = [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemCancel
                                                                                  target:self
                                                                                  action:@selector(cancel:)];
    [cancelButton setTitleTextAttributes:@{NSFontAttributeName : [UIFont boldSystemFontOfSize:17]}
                                forState:UIControlStateNormal];
    self.navigationItem.leftBarButtonItem = cancelButton;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    // Register cells and supplementary views
    [self.collectionView registerNib:[UINib nibWithNibName:@"AnneProductCell" bundle:nil]
          forCellWithReuseIdentifier:@"Product"];
    [self.collectionView registerNib:[UINib nibWithNibName:@"AnneProductClusterHeaderCell" bundle:nil]
          forSupplementaryViewOfKind:UICollectionElementKindSectionHeader
                 withReuseIdentifier:@"SectionHeader"];
    
    // Configure flow layout
    UICollectionViewFlowLayout *layout = (id)[self collectionViewLayout];
    layout.sectionInset = UIEdgeInsetsMake(0, 0, 20, 0);
    layout.minimumLineSpacing = 0;
    layout.headerReferenceSize = CGSizeMake(100, 30);
    
    self.collectionView.collectionViewLayout = layout;
    self.collectionView.backgroundColor = [UIColor grayColor];
}

#pragma mark Collection View delegate & datasource

- (NSInteger)numberOfSectionsInCollectionView:(UICollectionView *)collectionView {
    return [self.productClusters count];
}

- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
    AnneProductCluster *productCluster = self.productClusters[section];
    return [productCluster.products count];
}

- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView
                  cellForItemAtIndexPath:(NSIndexPath *)indexPath {
    AnneProductViewCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:@"Product"
                                                                     forIndexPath:indexPath];
    AnneProductCluster *cluster = self.productClusters[indexPath.section];
    cell.product = cluster.products[indexPath.row];
    return cell;
}

- (BOOL)collectionView:(UICollectionView *)collectionView
shouldHighlightItemAtIndexPath:(NSIndexPath *)indexPath {
    return YES;
}

- (BOOL)collectionView:(UICollectionView *)collectionView
shouldSelectItemAtIndexPath:(NSIndexPath *)indexPath; {
    return YES;
}

#pragma mark - Flow Layout Delegate

- (CGSize)collectionView:(UICollectionView *)collectionView
                  layout:(UICollectionViewLayout*)collectionViewLayout
  sizeForItemAtIndexPath:(NSIndexPath *)indexPath {
    return CGSizeMake(320, 116);
}
- (UICollectionReusableView *)collectionView:(UICollectionView *)collectionView
           viewForSupplementaryElementOfKind:(NSString *)kind
                                 atIndexPath:(NSIndexPath *)indexPath {
    if ([kind isEqual:UICollectionElementKindSectionHeader]) {
        AnneProductClusterHeaderCell *cell = [self.collectionView
                                             dequeueReusableSupplementaryViewOfKind:kind
                                             withReuseIdentifier:@"SectionHeader"
                                             forIndexPath:indexPath];
        
        cell.headerText = [self.productClusters[indexPath.section] title];
        return cell;
    }
    return nil;
}

#pragma mark SKStoreProductViewControllerDelegate

- (void)productViewControllerDidFinish:(SKStoreProductViewController *)viewController {
    [viewController dismissViewControllerAnimated:YES completion:nil];
}

#pragma mark private

- (AnneProduct *)productAtIndexPath:(NSIndexPath *)indexPath {
    AnneProductCluster *cluster = self.productClusters[indexPath.section];
    return cluster.products[indexPath.row];
}

- (IBAction)cancel:(id)sender {
    [self.parent dismissViewControllerAnimated:YES completion:^{
        if ([self.delegate respondsToSelector:@selector(multiProductViewControllerDidFinish:)]) {
            [self.delegate multiProductViewControllerDidFinish:self];
        }
    }];
}

@end
