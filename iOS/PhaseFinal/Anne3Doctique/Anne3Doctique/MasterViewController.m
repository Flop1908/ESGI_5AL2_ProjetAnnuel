//
//  AnneViewController.m
//  Demo2
//
//  Created by Kapi on 23/05/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import "AnneAirViewController.h"
#import "MasterViewController.h"
#import "DetailViewController.h"

@implementation MasterViewController

- (void)awakeFromNib
{
    [super awakeFromNib];
}
- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Release any cached data, images, etc that aren't in use.
}

#pragma mark - View lifecycle

- (void)viewDidLoad
{
    [super viewDidLoad];
    UIButton * button = [UIButton buttonWithType:UIButtonTypeCustom];
    button.frame = CGRectMake(0, 0, 50, 35);
    [button setTitle:@"Menu" forState:UIControlStateNormal];
    [button setTitleColor:[UIColor redColor] forState:UIControlStateNormal];
    [button setTitleColor:[UIColor blueColor] forState:UIControlStateHighlighted];
    [button addTarget:self action:@selector(leftButtonTouch) forControlEvents:UIControlEventTouchUpInside];
    self.navigationItem.leftBarButtonItem = [[UIBarButtonItem alloc] initWithCustomView:button];
    
    typeof(self) bself = self;
    self.AnneSwipeHander = ^{
        [bself.airViewController showAirViewFromViewController:bself.navigationController complete:nil];
    };
    maListe = [NSMutableArray array];
    [maListe addObject:@"Paris"];
    [maListe addObject:@"Lyon"];
    [maListe addObject:@"Marseille"];
    [maListe addObject:@"Toulouse"];
    [maListe addObject:@"Nantes"];
    [maListe addObject:@"Nice"];
    [maListe addObject:@"Bordeaux"];
    [maListe addObject:@"Montpellier"];
    [maListe addObject:@"Rennes"];
    [maListe addObject:@"Lille"];
    [maListe addObject:@"Le Havre"];
    [maListe addObject:@"Reims"];
    [maListe addObject:@"Le Mans"];
    [maListe addObject:@"Dijon"];
    [maListe addObject:@"Grenoble"];
    [maListe addObject:@"Brest"]; self.navigationItem.title = @"Grandes villes";
    
}

- (void)leftButtonTouch
{
    [self.airViewController showAirViewFromViewController:self.navigationController complete:nil];
}
/*
- (UILabel*)label
{
    if (!_label) {
        _label = [[UILabel alloc] initWithFrame:CGRectMake(0, 80, 320, 40)];
        _label.backgroundColor = [UIColor clearColor];
        _label.textAlignment = NSTextAlignmentCenter;
        _label.font = [UIFont boldSystemFontOfSize:16];
        _label.textColor = [UIColor redColor];
        [self.view addSubview:_label];
    }
    return _label;
}*/

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [maListe count];
}
                                                                       
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell * cell = [tableView dequeueReusableCellWithIdentifier:@"MyIdentifier"];
    // Configuration de la cellule
    NSString * cellValue = [maListe objectAtIndex:indexPath.row];
    cell.textLabel.text = cellValue;
    return cell;
}
-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender{
    if([[segue identifier] isEqualToString:@"detailSegue"]){
        NSInteger selectedIndex = [[self.tableView indexPathForSelectedRow]row];
        DetailViewController * dvc = [segue destinationViewController];
        dvc.texteAAfficher = [NSString stringWithFormat:@"%@", [maListe objectAtIndex:selectedIndex]];
    }
}
- (void)viewDidUnload
{
    [super viewDidUnload];
        // Release any retained subviews of the main view. // e.g. self.myOutlet = nil;
}
- (void)viewWillAppear:(BOOL)animated
{
    [super viewWillAppear:animated];
}
- (void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
}
- (void)viewWillDisappear:(BOOL)animated
{
    [super viewWillDisappear:animated];
}
- (void)viewDidDisappear:(BOOL)animated
{
    [super viewDidDisappear:animated];
}
-(BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown) ;
}
@end