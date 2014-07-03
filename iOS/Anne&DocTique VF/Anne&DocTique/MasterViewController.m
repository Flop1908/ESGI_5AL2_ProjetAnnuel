//
//  MasterViewController.m
//  Anne&DocTique
//
//  Created by Kapi on 29/01/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "MasterViewController.h"
#import "DetailCell.h"
#import "Group.h"
#import "AnneManager.h"
#import "AnneCommunicator.h"
#import "AnneAirViewController.h"

@interface MasterViewController () <AnneManagerDelegate> {
    NSArray *_groups;
    AnneManager *_manager;
}
@property (weak, nonatomic) CLLocationManager *locationManager;
@end

@implementation MasterViewController

//As the title of this, this function is load when the class is called
- (void)viewDidLoad
{
    [super viewDidLoad];
    NSLog(@"MasterView's Did load is Beginning");
    _manager = [[AnneManager alloc] init];
    
    _manager.communicator = [[AnneCommunicator alloc] init];
    
    _manager.communicator.delegate = _manager;
    
    _manager.delegate = self;
    
    //creation of Menu's Button
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

    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(startFetchingCountry:)
                                                 name:@"kCLAuthorizationStatusAuthorized"
                                               object:nil];
    NSLog(@"MasterView's Did load is Ending");
   
}
- (IBAction)viewFavoris:(id)sender {
}
- (IBAction)viewTop:(id)sender {
}
- (IBAction)viewRecent:(id)sender {
}
- (IBAction)viewRandom:(id)sender {
}
- (IBAction)viewFlop:(id)sender {
}

#pragma mark - Accessors
//For The Version 2, We can localize The user To have Country's anecdotes
- (CLLocationManager *)locationManager
{
    if (_locationManager) {
        return _locationManager;
    }
    
    id appDelegate = [[UIApplication sharedApplication] delegate];
    if ([appDelegate respondsToSelector:@selector(locationManager)]) {
        _locationManager = [appDelegate performSelector:@selector(locationManager)];
    }
    return _locationManager;
}

#pragma mark - Notification Observer
//For The Version 2, It's the user's Notification for the localisation
- (void)startFetchingCountry:(NSNotification *)notification
{
    [_manager fetchCountryAtCoordinate:self.locationManager.location.coordinate];
}

#pragma mark - AnneManagerDelegate
- (void)didReceiveGroup:(NSArray *)groups
{
    _groups = groups;
    [self.tableView reloadData];
}

//
- (void)fetchingCountryFailedWithError:(NSError *)error
{
    NSLog(@"Error %@; %@", error, [error localizedDescription]);
}


#pragma mark - Table View
//Function tell us how much there are in groups of the TableView
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return _groups.count;
}

//When a new cell was been passed in state Enable, this function was been loaded
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSLog(@"Cell For Row At Index Path's process is begginning");
    //Declaration of cellule type
    DetailCell *cell = [tableView dequeueReusableCellWithIdentifier:@"Cell" forIndexPath:indexPath];
    
    Group *group = _groups[indexPath.row];
    //[cell.nameLabel setText:group.Author];
    //[cell.whoLabel setText:group.Date];
    //Declaration of Label
    if ([group.Type isEqual:@"VDM"]) {
        [cell.avisLabel setText:[NSString stringWithFormat:@"Je Valide(%@)          Tu l'as bien merité(%@)", group.VotePlus, group.VoteMoins]];
        cell.backgroundColor= [UIColor colorWithRed:201/255.0f green:216/255.0f blue:237/255.0f alpha:0.3f];
    }
    if([group.Type isEqual:@"DTC"]){
        [cell.avisLabel setText:[NSString stringWithFormat:@"Good(%@)", group.VotePlus]];
        cell.backgroundColor= [UIColor colorWithRed:85/255.0f green:153/255.0f blue:85/255.0f alpha:1.0f];
        //cell.avisLabel.textColor= [UIColor colorWithRed:85/255.0f green:153/255.0f blue:85/255.0f alpha:1.0f];
        
    }
    if([group.Type isEqual:@"CNF"]){
        
     //   double division=((double *)group.Point/(double *)group.VoteMoins)*2;
     //   [cell.locationLabel setText:[NSString stringWithFormat:@"Note(%@)", division]];
        cell.backgroundColor=[UIColor colorWithRed:191/255.0f green:173/255.0f blue:130/255.0f alpha:0.4f];
        //cell.avisLabel.textColor=[UIColor colorWithRed:233/255.0f green:192/255.0f blue:143/255.0f alpha:1.0f];
    }
    
    [cell.descriptionLabel setText:group.Text];
    NSLog(@"Cell For Row At Index Path's process is done");
    return cell;
}

@end
