//
//  AnneMultiProductViewController.h
//  MultiProductViewer
//
//  Created by JN on 2014-3-19.
//  Copyright (c) 2014 thoughtbot, inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <StoreKit/StoreKit.h>

@protocol AnneMultiProductViewControllerDelegate;

@interface AnneMultiProductViewController : UICollectionViewController



+ (void)runWithTitle:(NSString *)title
     productClusters:(NSArray *)clusters
            delegate:(id <AnneMultiProductViewControllerDelegate>)delegate;

@end

@protocol AnneMultiProductViewControllerDelegate <NSObject>

@optional


- (void)multiProductViewControllerDidFinish:(AnneMultiProductViewController *)viewController;

@end